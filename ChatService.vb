Imports Microsoft.Extensions.Options
Imports RestSharp
Imports System.Collections.Generic
Imports System
 
Namespace WhatsappChatbotVB
    Public Class ChatService
        Private ReadOnly _appSettings As WhatsappChatbotVB.AppSettings
        Private ReadOnly _randomSentences As String() = New String() {"Money", "Time", "Coffee", "A Better Job", "A Life", "Better Programming Skills", "Internet that was mine", "More Beer", "More Donuts", "Candy", "My Daughter", "Cable", "A Dining Room Table", "Better Couches", "A PS4", "A New Laptop", "A New Phone", "Water", "Rum", "Movies", "A Desktop Computer", "A Fish Tank", "My Socks", "My Jacket", "More Coffee", "More Koolaid", "More Power", "A Truck", "Toolbox", "More fish for Fish Tank", "A Screwdriver", "A Projector", "More Pants"}
        Private ReadOnly _randomJoks As String() = New String() { "My boss arrived at work in a brand-new Lamborghini. ""Wow,"" I said. ""That's an amazing car."" He replied, ""If you work hard, put all your hours in, and strive for excellence, I'll get another one next year.""","What has ears but cannot hear? A cornfield" , "What’s a cat’s favorite dessert? A bowl full of mice-cream.","Why did the blue jay get in trouble at school? For tweeting on a test!"," Why are basketball courts always wet? Because the players dribble.","What do you call bears with no ears? B.","If you sit down to enjoy a hot cup of coffee, then your boss will ask you to do something that will last until the coffee is cold.  ","My boss arrived at work in a brand-new Lamborghini. ""Wow,"" I said. ""That's an amazing car."" He replied, ""If you work hard, put all your hours in, and strive for excellence, I'll get another one next year.""","My boss arrived at work in a brand-new Lamborghini. ""Wow,"" I said. ""That's an amazing car."" He replied, ""If you work hard, put all your hours in, and strive for excellence, I'll get another one next year.""","My boss arrived at work in a brand-new Lamborghini. ""Wow,"" I said. ""That's an amazing car."" He replied, ""If you work hard, put all your hours in, and strive for excellence, I'll get another one next year."""}
        Private ReadOnly _random As Random = New Random()
        Public Sub New(ByVal appSettings As IOptions(Of WhatsappChatbotVB.AppSettings))
            _appSettings = appSettings.Value
        End Sub
        Shared  welcomeMsg as Boolean = false
 
            dim goodChoice as Boolean= false
            const  welcomeStr as String = "Welcome to ultramsg bot Demo \n \nPlease type one of these *commands*:\n"
            const  whatsappMenu as String = 
                "1️⃣ : Show server time.\n"+
                "2️⃣ : Send Image.\n"+
                "3️⃣ : Send Document.\n"+
                "4️⃣ : Send Audio.\n"+
                "5️⃣ : Send Voice.\n"+
                "6️⃣ : Send Video.\n"+
                "7️⃣ : Send Contact.\n"+
                "8️⃣ : Send Random Sentence.\n"+
                "9️⃣ : Send Random Joke.\n"+
                "🔟 : Send Random Image.\n"

        Public Function OnChat(ByVal number As String, ByVal id As String) As String
            Dim client As RestClient = New RestClient()
           
            Dim request = New RestRequest(String.Empty, Method.Post)
            request.AddHeader("content-type", "application/x-www-form-urlencoded")
            request.AddQueryParameter("token", _appSettings.Token)
            request.AddQueryParameter("to", number)

           
            if (welcomeMsg = false) then 
                welcomeMsg = true
                id = "0"
                client = new RestClient($"https://api.ultramsg.com/{_appSettings.InstanceId}/messages/chat")
                request.AddQueryParameter("body", welcomeStr  + whatsappMenu)
                goodChoice=true
            end if 


            If Equals(id, "1") Then
                client = New RestClient($"https://api.ultramsg.com/{_appSettings.InstanceId}/messages/chat")
                request.AddQueryParameter("body", Date.Now)
                goodChoice = true
            End If

            If Equals(id, "2") Then
                client = New RestClient($"https://api.ultramsg.com/{_appSettings.InstanceId}/messages/image")
                request.AddQueryParameter("image", "https://file-example.s3-accelerate.amazonaws.com/images/test.jpg")
                request.AddQueryParameter("caption", "Image Caption")
                goodChoice = true
            End If

            If Equals(id, "3") Then
                client = New RestClient($"https://api.ultramsg.com/{_appSettings.InstanceId}/messages/document")
                request.AddQueryParameter("filename", "hello.pdf")
                request.AddQueryParameter("document", "https://file-example.s3-accelerate.amazonaws.com/documents/cv.pdf")
                goodChoice = true
            End If

            If Equals(id, "4") Then
                client = New RestClient($"https://api.ultramsg.com/{_appSettings.InstanceId}/messages/audio")
                request.AddQueryParameter("audio", "https://file-example.s3-accelerate.amazonaws.com/audio/2.mp3")
                goodChoice = true
            End If

            If Equals(id, "5") Then
                client = New RestClient($"https://api.ultramsg.com/{_appSettings.InstanceId}/messages/voice")
                request.AddQueryParameter("audio", "https://file-example.s3-accelerate.amazonaws.com/voice/oog_example.ogg")
                goodChoice = true
            End If

            If Equals(id, "6") Then
                client = New RestClient($"https://api.ultramsg.com/{_appSettings.InstanceId}/messages/video")
                request.AddQueryParameter("video", "https://file-example.s3-accelerate.amazonaws.com/video/test.mp4")
                request.AddQueryParameter("caption", "Video Caption")
                goodChoice = true
            End If

            If Equals(id, "7") Then
                client = New RestClient($"https://api.ultramsg.com/{_appSettings.InstanceId}/messages/contact")
                request.AddQueryParameter("contact", "14000000001@c.us")
                goodChoice = true
            End If

            If Equals(id, "8") Then
                client = New RestClient($"https://api.ultramsg.com/{_appSettings.InstanceId}/messages/chat")
                Dim randomIndex = _random.Next(0, _randomSentences.Length - 1)
                request.AddQueryParameter("body", _randomSentences(randomIndex))
                goodChoice = true
            End If

            If Equals(id, "9") Then
                client = New RestClient($"https://api.ultramsg.com/{_appSettings.InstanceId}/messages/chat")
                Dim randomIndex = _random.Next(0, _randomJoks.Count - 1)
                request.AddQueryParameter("body", _randomJoks(randomIndex))
                goodChoice = true
            End If

            If Equals(id, "10") Then
                client = New RestClient($"https://api.ultramsg.com/{_appSettings.InstanceId}/messages/image")
                Dim randomIndex = _random.Next(0, 100)
                request.AddQueryParameter("image", $"https://ultramsg.s3.us-west-2.amazonaws.com/image-example/{randomIndex}.jpg")
                request.AddQueryParameter("caption", $"Random Image {randomIndex}")
                goodChoice = true
            End If

            if (goodChoice =false) then 
                client = new RestClient($"https://api.ultramsg.com/{_appSettings.InstanceId}/messages/chat")
                request.AddQueryParameter("body", "``` 📢 Incorrect command 📢 ```\nPlease type one of these *commands*:\n" + whatsappMenu)
            end if 

            If client IsNot Nothing Then
                Dim response = client.Execute(request)
                If response.IsSuccessful Then Return String.Empty
                Return response.ErrorMessage
            End If
            Return String.Empty
        End Function
    End Class
End Namespace
