﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ofl.Interactive.Async
{
    public static partial class AsyncEnumerableExtensions
    {
        public static async Task<ReadOnlyCollection<T>> ToReadOnlyCollectionAsync<T>(this IAsyncEnumerable<T> source,
            CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (source == null) throw new ArgumentNullException(nameof(source));

            // Create the list, wrap.
            return new ReadOnlyCollection<T>(await source.ToList(cancellationToken).ConfigureAwait(false));
        }
    }
}
