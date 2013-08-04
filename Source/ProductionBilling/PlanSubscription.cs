using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductionBilling
{
    public class PlanSubscription
    {
        //see Mapper.MapChargifySubscriptionState()
        public static readonly IEnumerable<PlanSubscriptionState> LiveStates = new[] { PlanSubscriptionState.Active };
        public static readonly IEnumerable<PlanSubscriptionState> ProblemStates = new[] { PlanSubscriptionState.PastDue, PlanSubscriptionState.Unpaid };
        public static readonly IEnumerable<PlanSubscriptionState> EndOfLifeStates = new[] { PlanSubscriptionState.Ended, PlanSubscriptionState.Expired };

        internal int ChargifySubscriptionID { get; set; }
    
        public Plan Plan { get; internal set; }

        public Account Account { get; internal set; }

        internal PlanSubscription()
        {
        }

        public PlanSubscriptionState State { get; internal set; }

        public DateTime? TrialStartedAt { get; internal set; }

        public DateTime? TrialEndedAt { get; internal set; }

        public DateTime? ExpiresAt { get; internal set; }

        public DateTime CurrentPeriodStartedAt { get; internal set; }

        public DateTime CurrentPeriodEndsAt { get; internal set; }

        public DateTime ActivatedAt { get; internal set; }

        public DateTime NextAssessmentAt { get; internal set; }

        public bool IsLive
        {
            get { return IsStatusLive(State); }
        }

        public bool IsFinished
        {
            get { return EndOfLifeStates.Contains(State); }
        }

        public static bool IsStatusLive(PlanSubscriptionState state)
        {
            return LiveStates.Union(ProblemStates).Contains(state);
        }
    }
}