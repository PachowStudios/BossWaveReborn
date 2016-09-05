using PachowStudios.Framework.Messaging;

namespace PachowStudios.BossWave.Guns
{
  public class GunModel
  {
    private bool isActive;

    public bool IsActive
    {
      get { return this.isActive; }
      set
      {
        this.isActive = value; 
        RaiseIsActiveChanged();
      }
    }

    private IEventAggregator EventAggregator { get; }

    public GunModel(IEventAggregator eventAggregator)
    {
      EventAggregator = eventAggregator;
    }

    private void RaiseIsActiveChanged()
    {
      if (IsActive)
        EventAggregator.PublishLocally(new GunActivatedMessage());
      else
        EventAggregator.PublishLocally(new GunDeactivatedMessage());
    }
  }
}