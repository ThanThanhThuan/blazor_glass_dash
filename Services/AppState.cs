namespace BlazorDashboard.Services
{
    public class AppState
    {
        public string Theme { get; private set; } = "dark";
        public bool IsSidebarOpen { get; private set; }

        public event Action OnChange;

        public void SetTheme(string theme)
        {
            Theme = theme;
            NotifyStateChanged();
        }

        public void ToggleTheme()
        {
            Theme = Theme == "dark" ? "light" : "dark";
            NotifyStateChanged();
        }

        public void ToggleSidebar()
        {
            IsSidebarOpen = !IsSidebarOpen;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
