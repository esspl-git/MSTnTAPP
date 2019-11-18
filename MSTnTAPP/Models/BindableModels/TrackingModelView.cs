using System;

namespace MSTnTAPP.Models.BindingModels
{
    public class TrackingModelView:Tracking
    {
        public TrackingModelView(Tracking tracking)
        {
            LocationType = tracking.LocationType;
            LocationName = tracking.LocationName;
            OriginalEstimated = tracking.OriginalEstimated;
            CurrentEstimated = tracking.CurrentEstimated;
            ConfirmedActual = tracking.ConfirmedActual;
        }

        public string Original { get { try { return "Original Estimated: " + ((DateTime)OriginalEstimated).ToString("dd MMMM yyyy"); } catch (Exception e) { return ""; } } }
        public string Current { get { try { return "Current: " + ((DateTime)CurrentEstimated).ToString("dd MMMM yyyy"); } catch (Exception e) { return ""; } } }
        public string Actual { get { try { return "Confirmed Actual: "+ ((DateTime)ConfirmedActual).ToString("dd MMMM yyyy"); } catch (Exception e) { return ""; } } }
        public string StatusPointer
        {
            get
            {
                if (ConfirmedActual == null)
                {
                    return "done.png";
                }
                else
                {
                    return "pending.png";
                }
            }
        }
    }
}
