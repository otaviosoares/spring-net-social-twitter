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

namespace Spring.Social.Twitter.Api
{
    /// <summary>
    /// Represents a direct message.
    /// </summary>
    /// <author>Craig Walls</author>
    /// <author>Bruno Baia (.NET)</author>
    public class DirectMessage
    {
        /// <summary>
        /// Gets or sets the message ID.
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the user's profile that sent the message.
        /// </summary>
        public TwitterProfile Sender { get; set; }

        /// <summary>
        /// Gets or sets the user's profile that received the message.
        /// </summary>
        public TwitterProfile Recipient { get; set; }

        /// <summary>
        /// Gets or sets the message created date.
        /// </summary>
        public DateTime? CreatedAt { get; set; }
    }
}
