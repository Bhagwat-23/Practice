using System.ComponentModel;

namespace Project.CommonInfra.BaseClass
{
	public class BindableBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void Notify(string PropertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
			}
		}
	}
}
