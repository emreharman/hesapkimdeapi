using hesapkimdeapi.Data;
using hesapkimdeapi.Models;
using Microsoft.EntityFrameworkCore;

namespace hesapkimdeapi.Services
{
    public class AdTypeService : IAdTypeService
    {
        private readonly AppDbContext _context;
        public AdTypeService(AppDbContext context)
        {
            _context = context;
        }
        public List<AdType> AddAdType(AdType adType)
        {
            if(adType == null) return null;
            _context.AdTypes.Add(adType);
            _context.SaveChanges();
            return _context.AdTypes.ToList();
        }

        public List<AdType> DeleteAdType(int id)
        {
            if(id == null) return null;
            var foundAdType = this.GetAdType(id);
            _context.Entry(foundAdType).State = EntityState.Deleted;
            _context.SaveChanges();
            return _context.AdTypes.ToList();
            
        }

        public AdType GetAdType(int id)
        {
            if(id == null) return null;
            var adType = _context.AdTypes.FirstOrDefault(x => x.Id == id);
            return adType;
        }

        public  List<AdType> GetAdTypes()
        {
            return _context.AdTypes.ToList();
        }

        public AdType UpdateAdType(int id, AdType adType)
        {
            if(id == null || adType == null) return null;
            var foundAdType = this.GetAdType(id);
            if(foundAdType == null) return null;
            foundAdType.Type = adType.Type;
            _context.SaveChanges();
            return foundAdType;
        }
    }

    public interface IAdTypeService
    {
        List<AdType> GetAdTypes();
        AdType GetAdType(int id);
        List<AdType> AddAdType(AdType adType);
        AdType UpdateAdType(int id, AdType adType);
        List<AdType> DeleteAdType(int id);
    }
}