namespace FHSSpiritDataModelsFS

open System.ComponentModel

type ItemMessageCommentModel() =  
    let mutable m_nID : int = 0
    let mutable m_strCreationDateTime : string = ""
    let mutable m_strContent : string = ""
    let mutable m_strOwner : string = ""
    let mutable str : string = ""

    let ev = new Event<_,_>()
    interface INotifyPropertyChanged with
        [<CLIEvent>]
        member x.PropertyChanged = ev.Publish

    member x.ID
        with get() = m_nID
        and set(id') =
                m_nID <- id'
                ev.Trigger(x, PropertyChangedEventArgs("ID"))

    member x.CreationDateTime
        with get() = m_strCreationDateTime
        and set(creationDateTime') =
                m_strCreationDateTime <- creationDateTime'
                ev.Trigger(x, PropertyChangedEventArgs("CreationDateTime"))

    member x.Content
        with get() = m_strContent
        and set(content') =
                m_strContent <- content'
                ev.Trigger(x, PropertyChangedEventArgs("Content"))
                
    member x.Owner
        with get() = m_strOwner
        and set(owner') =
                m_strOwner <- owner'
                ev.Trigger(x, PropertyChangedEventArgs("Owner"))

    member x.StringProp
        with get() = str
            and set(str') =
                str <- str'
                ev.Trigger(x, PropertyChangedEventArgs("StringProp"))

