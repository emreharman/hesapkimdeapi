
using hesapkimdeapi.Data;
using hesapkimdeapi.Models;
using Microsoft.EntityFrameworkCore;

namespace hesapkimdeapi.Services;

public class AdsService : IAdsService
{
    private readonly AppDbContext _context;
    public AdsService(AppDbContext context)
    {
        _context = context;
    }
    public List<Ad> AddAd(Ad ad)
    {
        if (ad == null) return null;
        _context.Ads.Add(ad);
        _context.SaveChanges();
        return this.GetAds();
    }

    public Ad GetAd(int id)
    {
        if (id == null) return null;
        var existingAd = _context.Ads.Include(x => x.AdType).Include(x => x.Screen).FirstOrDefault(x => x.Id == id);
        if (existingAd == null) return null;
        return existingAd;
    }

    public List<Ad> GetAds()
    {
        return _context.Ads.Include(x => x.AdType).Include(x => x.Screen).ToList();
    }

    public Ad UpdateAd(int id, Ad ad)
    {
        if(id == null || ad == null) return null;
        var existingAd = this.GetAd(id);
        if(existingAd == null) return null;
        existingAd.AdvertisamentId = ad.AdvertisamentId;
        existingAd.IsActive = ad.IsActive;
        existingAd.ScreenId = ad.ScreenId;
        existingAd.AdTypeId = ad.AdTypeId;
        _context.SaveChanges();
        return this.GetAd(id);
    }
    public List<Ad> DeleteAd(int id)
    {
        if(id == null) return null;
        var existingAd = this.GetAd(id);
        if(existingAd == null) return null;
        _context.Entry(existingAd).State = EntityState.Deleted;
        _context.SaveChanges();
        return this.GetAds();
    }
}

public interface IAdsService
{
    List<Ad> GetAds();
    Ad GetAd(int id);
    List<Ad> AddAd(Ad ad);
    Ad UpdateAd(int id, Ad ad);
    List<Ad> DeleteAd(int id);
}