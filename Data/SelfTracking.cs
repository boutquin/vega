namespace Vega.Data
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class SelfTracking : INotifyPropertyChanged
    {
        private bool wasModified;

        public bool WasModified
        {
            get { return this.wasModified; }
            set { this.SetWithNotify(value, ref this.wasModified); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetWithNotify<T>(T value, ref T field, [CallerMemberName] string propertyName = "")
        {
            if (Equals(field, value)) return;
            field = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}