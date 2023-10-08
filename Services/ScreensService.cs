using hesapkimdeapi.Data;
using hesapkimdeapi.Models;

namespace hesapkimdeapi.Services
{
    public class ScreensService : IScreenService
    {
        private readonly AppDbContext _context;
        public ScreensService(AppDbContext context)
        {
            _context = context;
        }
        public List<Screen> AddScreen(Screen screen)
        {
            if(screen == null) return null;
            _context.Screens.Add(screen);
            _context.SaveChanges();
            return _context.Screens.ToList();
        }

        public List<Screen> DeleteScreen(int id)
        {
            if(id == null) return null;
            var existingScreen = this.GetScreen(id);
            _context.Entry(existingScreen).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return this.GetScreens();
        }

        public Screen GetScreen(int id)
        {
            if(id == null) return null;
            var existingScreen = _context.Screens.FirstOrDefault(x => x.Id == id);
            return existingScreen;
        }

        public List<Screen> GetScreens()
        {
            return _context.Screens.ToList();
        }

        public Screen UpdateScreen(int id, Screen screen)
        {
            if(id == null || screen == null) return null;
            var existingScreen = this.GetScreen(id);
            if(existingScreen == null) return null;
            existingScreen.Name = screen.Name;
            _context.SaveChanges();
            return existingScreen;
        }
    }
    public interface IScreenService
    {
        List<Screen> GetScreens();
        List<Screen> AddScreen(Screen screen);
        Screen GetScreen(int id);
        Screen UpdateScreen(int id, Screen screen);
        List<Screen> DeleteScreen(int id);
    }
}