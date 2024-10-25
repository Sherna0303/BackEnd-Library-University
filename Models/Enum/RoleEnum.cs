using System.Text.Json.Serialization;

namespace LibrarySystemWeb.Models.Enum
{
    [JsonConverter( typeof( JsonStringEnumConverter ) )]
    public enum RoleEnum
    {
        STUDENT,
        ADMIN,
    }
}
