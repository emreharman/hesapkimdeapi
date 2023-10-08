namespace hesapkimdeapi.Models;
public class Ad {
    public int Id { get; set; }
    public int AdTypeId { get; set; }
    public int ScreenId { get; set; }
    public bool IsActive { get; set; } = false;
    public string? AdvertisamentId { get; set; }
    public virtual AdType? AdType { get; set; }
    public virtual Screen? Screen { get; set; }
}