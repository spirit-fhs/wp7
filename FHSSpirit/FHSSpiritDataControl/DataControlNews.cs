using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;


using System.Collections.Generic;
using System.Linq;
//from Models
//using WindowsPhoneSpiritApplication;
using Newtonsoft.Json.Linq;

using FHSSpiritDataModels;
using FHSSpiritDataModelsFS;
using System.IO;
using System.Text;

namespace FHSSpiritDataControl
{
    public class DataControlNews
    {
        //note: DataControlNews is a Singleton 
        private static DataControlNews instance;

        public static DataControlNews Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataControlNews();
                }
                return instance;
            }
        }

        public delegate void ErrorMessage(string message);
        public delegate string GetURI();
        public delegate string GetFHSID();
        public delegate void ResponseNews(ItemMessageModel[] messages);

        public ErrorMessage m_del_ErrorMessage;
        public GetURI       m_del_GetUIR;
        public ResponseNews m_del_ResponseNews;
        public GetFHSID     m_del_GetFHSID;

        System.Uri m_UriDataSource;

        string m_strNewsPostFix     = "/fhs-spirit/news";
        string m_strCommentPostFix  = "/fhs-spirit/news/comment";

        //Members to add a new Comment
        string m_strNewComment = "";
        int m_nNewMessageID = -1;
        string m_strFHSID = "";

        private DataControlNews()
        {
        }

        public void requestAllNews()
        {
            try
            {
                this.m_UriDataSource = new Uri(this.m_del_GetUIR() + this.m_strNewsPostFix);

                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(this.m_UriDataSource);
                httpWebRequest.Method = "GET";
                // Set the ContentType property of the WebRequest.
                //httpWebRequest.Accept = "application/xml";
                httpWebRequest.Accept = "application/json";
                //httpWebRequest.Headers = "";
                var result = (IAsyncResult)httpWebRequest.BeginGetResponse(ResponseCallback, httpWebRequest);
            }
            catch (Exception ex)
            {
                this.m_del_ErrorMessage(ex.Message);
            }
        }

        private void ResponseCallback(IAsyncResult result)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)result.AsyncState;

                WebResponse response = httpWebRequest.EndGetResponse(result);

                System.IO.Stream stream = response.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);

                string strJSON = sr.ReadToEnd();

                processJSONString(strJSON);
            }
            catch (Exception ex)
            {
                this.m_del_ErrorMessage(ex.Message);
            }
        }

        public void addComment(string strComments, int nCurrentMessageID)
        {
            try
            {
                this.m_UriDataSource = new Uri(this.m_del_GetUIR() + this.m_strCommentPostFix);

                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(this.m_UriDataSource);
                httpWebRequest.Method = "PUT";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.ContentType = "application/json";

                this.m_strNewComment = strComments;
                this.m_nNewMessageID = nCurrentMessageID;
                this.m_strFHSID      = this.m_del_GetFHSID();

                var result = (IAsyncResult)httpWebRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), httpWebRequest);
            }
            catch (Exception ex)
            {
                this.m_del_ErrorMessage(ex.Message);
            }
        }

        private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

            // End the operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);

            //sample
            string postData = "{\"newsComment\":{\"content\":\"" + this.m_strNewComment + "\",\"news\":{\"news_id\":" + this.m_nNewMessageID.ToString() + "},\"owner\":{\"fhs_id\":\"" + this.m_strFHSID + "\"}}}";
            // Convert the string into a byte array.
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //Latin 1
            //byte[] byteArray = System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(postData);

            // Write to the request stream.
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();

            // Start the asynchronous operation to get the response
            request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        }

        private void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

                // End the operation
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);
                string responseString = streamRead.ReadToEnd();
                Console.WriteLine(responseString);
                // Close the stream object
                streamResponse.Close();
                streamRead.Close();

                // Release the HttpWebResponse
                response.Close();
            }
            catch (Exception ex)
            {
                this.m_del_ErrorMessage(ex.Message);
            }
        }

        private void processJSONString(string strJSON)
        {

            JObject jObject = JObject.Parse(strJSON);

            var query = from resultArray in (JArray)jObject["news"]

                        let resultObject = resultArray as JObject

                        orderby (string)resultObject.SelectToken("creationDate") descending
                        //let resultObject2 = resultArray as JArray
                        //let degreeClasses = "MAI3, MAI7"
                        let flat = flatDegreeClasses(resultObject)
                        let comments = addComments(resultObject)

                        select new ItemMessageModel
                        {
                            Content = (string)resultObject.SelectToken("content"),
                            Course = flat,
                            CreationDateTime = (string)resultObject.SelectToken("creationDate"),
                            ExpireDate = (string)resultObject.SelectToken("expireDate"),
                            ID = (int)resultObject.SelectToken("news_id"),
                            Owner = (string)resultObject["owner"].SelectToken("displayedName"),
                            Title = (string)resultObject.SelectToken("title"),
                            CountComments = (int)(resultObject["newsComment"] as JArray).Count(),
                            NewsComments = comments
                        };

            ItemMessageModel[] messages = query.ToArray();

            this.m_del_ResponseNews(messages);
        }

        static private string flatDegreeClasses(JObject jObject)
        {
            var query = from resultArray in (JArray)jObject["degreeClass"]

            let resultObject = resultArray as JObject

            select new DegreeClass
            {
                DegClass = (string)resultObject.SelectToken("title")
            };

            DegreeClass[] degreeClasses = query.ToArray();

            string outputString = "";

            foreach (DegreeClass d in degreeClasses)
            {
                outputString += d.DegClass + " ";
            }

            return outputString;
        }

        static private ItemMessageCommentModel[] addComments(JObject jObject)
        {
               var query = from resultArray in (JArray)jObject["newsComment"]
                        
                        let resultObject = resultArray as JObject

                        //orderby (string)(resultObject["creationDate"] as JObject).SelectToken("creationDate") descending
                        orderby (string)resultObject.SelectToken("creationDate") descending

                        select new ItemMessageCommentModel
                        {
                            Content = (string)resultObject.SelectToken("content"),
                            //CreationDateTime = (string)(resultObject["creationDate"] as JObject).SelectToken("creationDate"),
                            CreationDateTime = (string)resultObject.SelectToken("creationDate"),
                            ID = (int)resultObject.SelectToken("comment_id"),
                            Owner = (string)resultObject["owner"].SelectToken("displayedName")
                        };

            ItemMessageCommentModel[] arrItemMessageCommentModel = query.ToArray();

            return arrItemMessageCommentModel;
        }

       
    }

    public class DegreeClass
    {
        private string m_strDegreeClass;

        public string DegClass
        {
            get
            {
                return m_strDegreeClass;
            }
            set
            {
                if (value != m_strDegreeClass)
                {
                    m_strDegreeClass = value;
                }
            }
        }
    };
}
