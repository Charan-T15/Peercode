namespace Peercode.Persistance.DbModels;

internal class DbChat
{
    public Guid ChatId { get; set; }

    public Guid FromUserId { get; set; }

    public Guid ToUserId { get; set; }

    public string? Message { get; set; }

    public DateTime SentAt { get; set; }

    public string? Attachments {  get; set; }


}
