﻿using System.Threading.Tasks;
using MyCouch.Requests;
using MyCouch.Responses;

namespace MyCouch
{
   /// <summary>
   /// Used to access Search Indexes.
   /// </summary>
   public interface ISearches
   {
       /// <summary>
       /// Lets you perform a search using Lucene powered
       /// Search API by using a reusable <see cref="SearchIndexRequest"/>.
       /// Any returned IncludedDoc will be treated as JSON.
       /// </summary>
       /// <param name="request"></param>
       /// <returns></returns>
       Task<SearchIndexResponse> SearchAsync(SearchIndexRequest request);

       /// <summary>
       /// Lets you perform a search using Lucene powered
       /// Search API by using a reusable <see cref="SearchIndexRequest"/>.
       /// Any returned IncludedDoc will be treated as <typeparamref name="TIncludedDoc"/>.
       /// </summary>
       /// <typeparam name="TIncludedDoc"></typeparam>
       /// <param name="request"></param>
       /// <returns></returns>
       Task<SearchIndexResponse<TIncludedDoc>> SearchAsync<TIncludedDoc>(SearchIndexRequest request);
   }
}