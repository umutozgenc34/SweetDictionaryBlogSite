

namespace SweetDictionaryBlogSite.Service.Constants;

public static class Messages
{
    public const string PostAddedMessage = "Post Eklendi";
    public const string PostUpdatedMessage = "Post Güncellendi";
    public const string PostDeletedMessage = "Post Silindi.";
    public static string PostIsNotPresentMessage(Guid id)
    {
        return $"İlgili id ye göre post bulunamadı : {id}";
    }
}
