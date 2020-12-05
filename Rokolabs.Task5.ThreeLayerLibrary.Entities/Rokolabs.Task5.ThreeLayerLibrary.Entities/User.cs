namespace Rokolabs.Task5.ThreeLayerLibrary.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public int RoleId { get; set; }
    }
}