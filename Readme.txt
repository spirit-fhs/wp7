Ronny Schleicher, 23.10.2011, Windows Phone 7 FHS Spirit Application 

Installation requirements:

+Visual Studio 2010
+Windows Phone Developer Tools RTW

Note:

You have three ways to configure the connection settings with the FHS - Rest Service

In Project FHSSpirit -> File MainPage.xaml.cs:

The methode returns follow connection strings.

public string getURI()
{
   //connect with the real Windows Phone 7(only with the FHS certificate)
   //return "https://212.201.64.226:8443";

   //connect with the Emulator and FHS VPN
   return "http://212.201.64.226:8080";

  //use the Settings in the UI
  //return this.textBlockURI.Text;
}

Please choose the return value for your own case. 
