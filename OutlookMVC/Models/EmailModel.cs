using System;
using System.Collections.Generic;

public class EmailModel
{
    public string odata_context { get; set; }
    public List<ValueItem> value { get; set; }
}

public class ValueItem
{
    public string odata_etag { get; set; }
    public string id { get; set; }
    public DateTime createdDateTime { get; set; }
    public DateTime lastModifiedDateTime { get; set; }
    public string changeKey { get; set; }
    public List<object> categories { get; set; }
    public DateTime receivedDateTime { get; set; }
    public DateTime sentDateTime { get; set; }
    public bool hasAttachments { get; set; }
    public string internetMessageId { get; set; }
    public string subject { get; set; }
    public string bodyPreview { get; set; }
    public string importance { get; set; }
    public string parentFolderId { get; set; }
    public string conversationId { get; set; }
    public string conversationIndex { get; set; }
    public bool? isDeliveryReceiptRequested { get; set; }
    public bool isReadReceiptRequested { get; set; }
    public bool isRead { get; set; }
    public bool isDraft { get; set; }
    public string webLink { get; set; }
    public string inferenceClassification { get; set; }
    public Body body { get; set; }
    public Sender sender { get; set; }
    public From from { get; set; }
    public List<ToRecipient> toRecipients { get; set; }
    public List<object> ccRecipients { get; set; }
    public List<object> bccRecipients { get; set; }
    public List<object> replyTo { get; set; }
    public Flag flag { get; set; }
}

public class Body
{
    public string contentType { get; set; }
    public string content { get; set; }
}

public class Sender
{
    public EmailAddress emailAddress { get; set; }
}

public class From
{
    public EmailAddress emailAddress { get; set; }
}

public class ToRecipient
{
    public EmailAddress emailAddress { get; set; }
}

public class EmailAddress
{
    public string name { get; set; }
    public string address { get; set; }
}

public class Flag
{
    public string flagStatus { get; set; }
}