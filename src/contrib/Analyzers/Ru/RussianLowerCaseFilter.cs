/*
 *
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 *
*/

using System;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Tokenattributes;

namespace Lucene.Net.Analysis.Ru
{
    /// <summary>
    /// Normalizes token text to lower case.
    /// </summary>
    [Obsolete("Use LowerCaseFilter instead, which has the same functionality. This filter will be removed in Lucene 4.0")]
    public sealed class RussianLowerCaseFilter : TokenFilter
    {
        private TermAttribute termAtt;

        public RussianLowerCaseFilter(TokenStream _in)
            : base(_in)
        {
            termAtt = AddAttribute<TermAttribute>();
        }

        public sealed override bool IncrementToken()
        {
            if (input.IncrementToken())
            {
                char[] chArray = termAtt.TermBuffer();
                int chLen = termAtt.TermLength();
                for (int i = 0; i < chLen; i++)
                {
                    chArray[i] = char.ToLower(chArray[i]);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}