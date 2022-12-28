using FitDash.Diet.Domain.Enums;

namespace FitDash.Diet.Domain.Extensions
{
    public static class EActivityFactorExtensions
    {
        /// <summary>
        /// Returns the actual value of the activity factor coefficient
        /// </summary>
        /// <param name="activityFactor">enum EActivityFactor</param>
        /// <returns>decimal value</returns>
        public static decimal GetValue(this EActivityFactor activityFactor)
        {
            switch (activityFactor)
            {
                case EActivityFactor.SEDENTARY:
                    return 1.3m;
                case EActivityFactor.LIGHTLY_ACTIVE:
                    return 1.4m;
                case EActivityFactor.BEGINNER_TRAINING:
                    return 1.5m;
                case EActivityFactor.ADVANCED_TRAINING:
                    return 1.6m;
                case EActivityFactor.EXTREMELY_ADVANCED_TRAINING:
                    return 1.7m;
                default:
                    return 1.5m;
            }
        }

    }
}
