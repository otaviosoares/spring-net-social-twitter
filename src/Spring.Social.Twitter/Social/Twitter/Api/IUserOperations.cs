﻿#region License

/*
 * Copyright 2002-2012 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using System.IO;
using System.Collections.Generic;
#if NET_4_0 || SILVERLIGHT_5
using System.Threading.Tasks;
#else
using Spring.Rest.Client;
using Spring.Http;
#endif

namespace Spring.Social.Twitter.Api
{
    /// <summary>
    /// Interface defining the operations for searching Twitter and retrieving trending data.
    /// </summary>
    /// <author>Craig Walls</author>
    /// <author>Bruno Baia (.NET)</author>
    public interface IUserOperations
    {
#if NET_4_0 || SILVERLIGHT_5       
	    /// <summary>
        /// Asynchronously retrieves the authenticated user's Twitter profile details.
	    /// </summary>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a <see cref="TwitterProfile"/>object representing the user's profile.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="TwitterApiException">If OAuth credentials was not provided.</exception>
	    Task<TwitterProfile> GetUserProfileAsync();

        /// <summary>
        /// Asynchronously retrieves a specific user's Twitter profile details. 
        /// Note that this method does not require authentication.
        /// </summary>
        /// <param name="screenName">The screen name for the user whose details are to be retrieved.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a <see cref="TwitterProfile"/> object representing the user's profile.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        Task<TwitterProfile> GetUserProfileAsync(string screenName);

        /// <summary>
        /// Asynchronously retrieves a specific user's Twitter profile details. 
        /// Note that this method does not require authentication.
        /// </summary>
        /// <param name="userId">The user ID for the user whose details are to be retrieved.</param>
        /// <returns>A <see cref="TwitterProfile"/> object representing the user's profile.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        Task<TwitterProfile> GetUserProfileAsync(long userId);

        /// <summary>
        /// Asynchronously retrieves the user's profile image. Returns the image in Twitter's "normal" size (48px x 48px).
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// an array of bytes containing the user's profile image.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        Task<byte[]> GetUserProfileImageAsync(string screenName);

        /// <summary>
        /// Asynchronously retrieves the user's profile image. Returns the image in Twitter's "normal" type.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="size">The size of the image.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// an array of bytes containing the user's profile image.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        Task<byte[]> GetUserProfileImageAsync(string screenName, ImageSize size);

        /// <summary>
        /// Asynchronously retrieves a list of Twitter profiles for the given list of user IDs.
        /// </summary>
        /// <param name="userIds">The list of user IDs.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a list of <see cref="TwitterProfile">user's profiles</see>.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        Task<IList<TwitterProfile>> GetUsersAsync(params long[] userIds);

        /// <summary>
        /// Asynchronously retrieves a list of Twitter profiles for the given list of screen names.
        /// </summary>
        /// <param name="screenNames">The list of screen names.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a list of <see cref="TwitterProfile">user's profiles</see>.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        Task<IList<TwitterProfile>> GetUsersAsync(params string[] screenNames);

        /// <summary>
        /// Asynchronously searches for up to 20 users that match a given query.
        /// </summary>
        /// <param name="query">The search query string.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a list of <see cref="TwitterProfile">user's profiles</see>.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="TwitterApiException">If OAuth credentials was not provided.</exception>
        Task<IList<TwitterProfile>> SearchForUsersAsync(string query);

        /// <summary>
        /// Asynchronously searches for users that match a given query.
        /// </summary>
        /// <param name="query">The search query string.</param>
        /// <param name="page">The page of search results to return.</param>
        /// <param name="pageSize">The number of <see cref="TwitterProfile"/>s per page. Maximum of 20 per page.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a list of <see cref="TwitterProfile">user's profiles</see>.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="TwitterApiException">If OAuth credentials was not provided.</exception>
        Task<IList<TwitterProfile>> SearchForUsersAsync(string query, int page, int pageSize);

        /// <summary>
        /// Asynchronously retrieves a list of categories from which suggested users to follow may be found.
        /// </summary>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a list of suggestion categories.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        Task<IList<SuggestionCategory>> GetSuggestionCategoriesAsync();

        /// <summary>
        /// Asynchronously retrieves a list of suggestions of users to follow for a given category.
        /// </summary>
        /// <param name="slug">The category's slug.</param>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// a list of <see cref="TwitterProfile">user's profiles</see>.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        Task<IList<TwitterProfile>> GetSuggestionsAsync(string slug);

        /// <summary>
        /// Asynchronously retrieves the rate limit status. 
        /// Can be used with either an authorized or unauthorized TwitterTemplate.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the TwitterTemplate is authorized, the rate limits apply to the authenticated user.
        /// </para>
        /// <para>
        /// If the TwitterTemplate is unauthorized, the rate limits apply to the IP address from with the request is made. 
        /// </para>
        /// </remarks>
        /// <returns>
        /// A <code>Task</code> that represents the asynchronous operation that can return 
        /// the rate limit status.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        Task<RateLimitStatus> GetRateLimitStatusAsync();
#else
#if !SILVERLIGHT
	    /// <summary>
        /// Retrieves the authenticated user's Twitter profile details.
	    /// </summary>
        /// <returns>A <see cref="TwitterProfile"/>object representing the user's profile.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="TwitterApiException">If OAuth credentials was not provided.</exception>
	    TwitterProfile GetUserProfile();

        /// <summary>
        /// Retrieves a specific user's Twitter profile details. 
        /// Note that this method does not require authentication.
        /// </summary>
        /// <param name="screenName">The screen name for the user whose details are to be retrieved.</param>
        /// <returns>A <see cref="TwitterProfile"/> object representing the user's profile.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
	    TwitterProfile GetUserProfile(string screenName);

        /// <summary>
        /// Retrieves a specific user's Twitter profile details. 
        /// Note that this method does not require authentication.
        /// </summary>
        /// <param name="userId">The user ID for the user whose details are to be retrieved.</param>
        /// <returns>A <see cref="TwitterProfile"/> object representing the user's profile.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
	    TwitterProfile GetUserProfile(long userId);

        /// <summary>
        /// Retrieves the user's profile image. Returns the image in Twitter's "normal" size (48px x 48px).
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An array of bytes containing the user's profile image.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
	    byte[] GetUserProfileImage(string screenName);

        /// <summary>
        /// Retrieves the user's profile image. Returns the image in Twitter's "normal" type.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="size">The size of the image.</param>
        /// <returns>An array of bytes containing the user's profile image.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
	    byte[] GetUserProfileImage(string screenName, ImageSize size);

        /// <summary>
        /// Retrieves a list of Twitter profiles for the given list of user IDs.
        /// </summary>
        /// <param name="userIds">The list of user IDs.</param>
        /// <returns>A list of <see cref="TwitterProfile">user's profiles</see>.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
	    IList<TwitterProfile> GetUsers(params long[] userIds);

        /// <summary>
        /// Retrieves a list of Twitter profiles for the given list of screen names.
        /// </summary>
        /// <param name="screenNames">The list of screen names.</param>
        /// <returns>A list of <see cref="TwitterProfile">user's profiles</see>.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
	    IList<TwitterProfile> GetUsers(params string[] screenNames);

        /// <summary>
        /// Searches for up to 20 users that match a given query.
        /// </summary>
        /// <param name="query">The search query string.</param>
        /// <returns>A list of <see cref="TwitterProfile">user's profiles</see>.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="TwitterApiException">If OAuth credentials was not provided.</exception>
	    IList<TwitterProfile> SearchForUsers(string query);

        /// <summary>
        /// Searches for users that match a given query.
        /// </summary>
        /// <param name="query">The search query string.</param>
        /// <param name="page">The page of search results to return.</param>
        /// <param name="pageSize">The number of <see cref="TwitterProfile"/>s per page. Maximum of 20 per page.</param>
        /// <returns>A list of <see cref="TwitterProfile">user's profiles</see>.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="TwitterApiException">If OAuth credentials was not provided.</exception>
        IList<TwitterProfile> SearchForUsers(string query, int page, int pageSize);

        /// <summary>
        /// Retrieves a list of categories from which suggested users to follow may be found.
        /// </summary>
        /// <returns>A list of suggestion categories.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
	    IList<SuggestionCategory> GetSuggestionCategories();

        /// <summary>
        /// Retrieves a list of suggestions of users to follow for a given category.
        /// </summary>
        /// <param name="slug">The category's slug.</param>
        /// <returns>A list of <see cref="TwitterProfile">user's profiles</see>.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
	    IList<TwitterProfile> GetSuggestions(string slug);

        /// <summary>
        /// Retrieves the rate limit status. 
        /// Can be used with either an authorized or unauthorized TwitterTemplate.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the TwitterTemplate is authorized, the rate limits apply to the authenticated user.
        /// </para>
        /// <para>
        /// If the TwitterTemplate is unauthorized, the rate limits apply to the IP address from with the request is made. 
        /// </para>
        /// </remarks>
        /// <returns>The rate limit status.</returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
	    RateLimitStatus GetRateLimitStatus();
#endif

        /// <summary>
        /// Asynchronously retrieves the authenticated user's Twitter profile details.
        /// </summary>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a <see cref="TwitterProfile"/>object representing the user's profile.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="TwitterApiException">If OAuth credentials was not provided.</exception>
        RestOperationCanceler GetUserProfileAsync(Action<RestOperationCompletedEventArgs<TwitterProfile>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves a specific user's Twitter profile details. 
        /// Note that this method does not require authentication.
        /// </summary>
        /// <param name="screenName">The screen name for the user whose details are to be retrieved.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a <see cref="TwitterProfile"/> object representing the user's profile.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        RestOperationCanceler GetUserProfileAsync(string screenName, Action<RestOperationCompletedEventArgs<TwitterProfile>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves a specific user's Twitter profile details. 
        /// Note that this method does not require authentication.
        /// </summary>
        /// <param name="userId">The user ID for the user whose details are to be retrieved.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a <see cref="TwitterProfile"/> object representing the user's profile.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        RestOperationCanceler GetUserProfileAsync(long userId, Action<RestOperationCompletedEventArgs<TwitterProfile>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves the user's profile image. Returns the image in Twitter's "normal" size (48px x 48px).
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides an array of bytes containing the user's profile image.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        RestOperationCanceler GetUserProfileImageAsync(string screenName, Action<RestOperationCompletedEventArgs<byte[]>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves the user's profile image. Returns the image in Twitter's "normal" type.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="size">The size of the image.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides an array of bytes containing the user's profile image.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        RestOperationCanceler GetUserProfileImageAsync(string screenName, ImageSize size, Action<RestOperationCompletedEventArgs<byte[]>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves a list of Twitter profiles for the given list of user IDs.
        /// </summary>
        /// <param name="userIds">The list of user IDs.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a list of <see cref="TwitterProfile">user's profiles</see>.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        RestOperationCanceler GetUsersAsync(long[] userIds, Action<RestOperationCompletedEventArgs<IList<TwitterProfile>>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves a list of Twitter profiles for the given list of screen names.
        /// </summary>
        /// <param name="screenNames">The list of screen names.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a list of <see cref="TwitterProfile">user's profiles</see>.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        RestOperationCanceler GetUsersAsync(string[] screenNames, Action<RestOperationCompletedEventArgs<IList<TwitterProfile>>> operationCompleted);

        /// <summary>
        /// Asynchronously searches for up to 20 users that match a given query.
        /// </summary>
        /// <param name="query">The search query string.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a list of <see cref="TwitterProfile">user's profiles</see>.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="TwitterApiException">If OAuth credentials was not provided.</exception>
        RestOperationCanceler SearchForUsersAsync(string query, Action<RestOperationCompletedEventArgs<IList<TwitterProfile>>> operationCompleted);

        /// <summary>
        /// Asynchronously searches for users that match a given query.
        /// </summary>
        /// <param name="query">The search query string.</param>
        /// <param name="page">The page of search results to return.</param>
        /// <param name="pageSize">The number of <see cref="TwitterProfile"/>s per page. Maximum of 20 per page.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a list of <see cref="TwitterProfile">user's profiles</see>.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="TwitterApiException">If OAuth credentials was not provided.</exception>
        RestOperationCanceler SearchForUsersAsync(string query, int page, int pageSize, Action<RestOperationCompletedEventArgs<IList<TwitterProfile>>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves a list of categories from which suggested users to follow may be found.
        /// </summary>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a list of suggestion categories.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        RestOperationCanceler GetSuggestionCategoriesAsync(Action<RestOperationCompletedEventArgs<IList<SuggestionCategory>>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves a list of suggestions of users to follow for a given category.
        /// </summary>
        /// <param name="slug">The category's slug.</param>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides a list of <see cref="TwitterProfile">user's profiles</see>.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        RestOperationCanceler GetSuggestionsAsync(string slug, Action<RestOperationCompletedEventArgs<IList<TwitterProfile>>> operationCompleted);

        /// <summary>
        /// Asynchronously retrieves the rate limit status. 
        /// Can be used with either an authorized or unauthorized TwitterTemplate.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the TwitterTemplate is authorized, the rate limits apply to the authenticated user.
        /// </para>
        /// <para>
        /// If the TwitterTemplate is unauthorized, the rate limits apply to the IP address from with the request is made. 
        /// </para>
        /// </remarks>
        /// <param name="operationCompleted">
        /// The <code>Action&lt;&gt;</code> to perform when the asynchronous request completes. 
        /// Provides the rate limit status.
        /// </param>
        /// <returns>
        /// A <see cref="RestOperationCanceler"/> instance that allows to cancel the asynchronous operation.
        /// </returns>
        /// <exception cref="TwitterApiException">If there is an error while communicating with Twitter.</exception>
        RestOperationCanceler GetRateLimitStatusAsync(Action<RestOperationCompletedEventArgs<RateLimitStatus>> operationCompleted);
#endif
    }
}
