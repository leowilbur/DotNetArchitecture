using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Solution.CrossCutting.EntityFrameworkCore
{
    public static class EntityFrameworkCoreExtensions
    {
        public static void EnableDetectChangesLazyLoading(this DbContext context, bool enabled)
        {
            context.ChangeTracker.AutoDetectChangesEnabled = enabled;
            context.ChangeTracker.LazyLoadingEnabled = enabled;
            context.ChangeTracker.QueryTrackingBehavior = (enabled) ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking;
        }

        public static IQueryable<T> Include<T>(this IQueryable<T> queryable, Expression<Func<T, object>>[] inclusions) where T : class
        {
            inclusions?.ToList().ForEach(include => queryable = queryable.Include(include));
            return queryable;
        }
    }
}
