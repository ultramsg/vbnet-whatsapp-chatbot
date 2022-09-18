Imports System.Text.Json.Serialization

Namespace WhatsappChatbotVB
    Public Class Data
        <JsonPropertyName("id")>
        Public Property Id As String

        <JsonPropertyName("from")>
        Public Property From As String

        <JsonPropertyName("to")>
        Public Property [To] As String

        <JsonPropertyName("ack")>
        Public Property Ack As String

        <JsonPropertyName("type")>
        Public Property Type As String

        <JsonPropertyName("body")>
        Public Property Body As String

        <JsonPropertyName("media")>
        Public Property Media As String

        <JsonPropertyName("fromMe")>
        Public Property FromMe As Boolean

        <JsonPropertyName("isForwarded")>
        Public Property IsForwarded As Boolean

        <JsonPropertyName("time")>
        Public Property Time As Long
    End Class
    Public Class HookData
        <JsonPropertyName("event_type")>
        Public Property EventType As String

        <JsonPropertyName("instanceId")>
        Public Property InstanceId As String

        <JsonPropertyName("data")>
        Public Property Data As Data
    End Class
End Namespace
