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
using System.Globalization;

using Spring.Json;

namespace Spring.Social.Twitter.Api.Impl.Json
{
    /// <summary>
    /// JSON deserializer for rate limit status. 
    /// </summary>
    /// <author>Craig Walls</author>
    /// <author>Bruno Baia (.NET)</author>
    class RateLimitStatusDeserializer : IJsonDeserializer
    {
        private const string RATE_LIMIT_STATUS_DATE_FORMAT = "ddd MMM dd HH:mm:ss zzz yyyy";

        public object Deserialize(JsonValue value, JsonMapper mapper)
        {
            return new RateLimitStatus()
            {
                HourlyLimit = value.GetValue<int>("hourly_limit"),
                RemainingHits = value.GetValue<int>("remaining_hits"),
                ResetTime = JsonUtils.ToDateTime(value.GetValue<string>("reset_time"), RATE_LIMIT_STATUS_DATE_FORMAT)
            };
        }
    }
}