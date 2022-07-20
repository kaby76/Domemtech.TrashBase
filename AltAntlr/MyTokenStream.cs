namespace AltAntlr
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Antlr4.Runtime;
    using Antlr4.Runtime.Misc;

    public class MyTokenStream : BufferedTokenStream, ITokenStream
    {
        public ITokenSource _tokenSource;
        protected new internal List<IToken> _tokens;
        protected internal int n;
        protected new internal int p = 0;
        protected internal int numMarkers = 0;
        protected internal IToken lastToken;
        protected internal IToken lastTokenBufferStart;
        protected internal int currentTokenIndex = 0;

        public class FuckYouAntlr : ITokenSource
        {
            public FuckYouAntlr() { }
            public int Line => throw new NotImplementedException();
            public int Column => throw new NotImplementedException();
            public ICharStream InputStream => throw new NotImplementedException();
            public string SourceName => throw new NotImplementedException();
            public ITokenFactory TokenFactory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            [return: NotNull]
            public IToken NextToken()
            {
                throw new NotImplementedException();
            }
        }

        public MyTokenStream()
            : base(new FuckYouAntlr())
        {
            this._tokens = new List<IToken>();
            n = 0;
            this._tokenSource = null;
        }

        public MyTokenStream(string t)
            : base(new FuckYouAntlr())
        {
            Text = t;
            this._tokens = new List<IToken>();
            n = 0;
            this._tokenSource = null;
        }

        public override IList<IToken> GetTokens()
        {
            return _tokens;
        }

        public override IToken Get(int i)
        {
            int bufferStartIndex = GetBufferStartIndex();
            if (i < bufferStartIndex || i >= bufferStartIndex + n)
            {
                throw new ArgumentOutOfRangeException("get(" + i + ") outside buffer: " + bufferStartIndex + ".." + (bufferStartIndex + n));
            }
            return _tokens[i - bufferStartIndex];
        }

        public override IToken LT(int i)
        {
            if (i == -1)
            {
                return lastToken;
            }
            Sync(i);
            int index = p + i - 1;
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("LT(" + i + ") gives negative index");
            }
            if (index >= n)
            {
                System.Diagnostics.Debug.Assert(n > 0 && _tokens[n - 1].Type == TokenConstants.EOF);
                return _tokens[n - 1];
            }
            return _tokens[index];
        }

        public override int LA(int i)
        {
            return LT(i).Type;
        }

        public override ITokenSource TokenSource
        {
            get
            {
                return _tokenSource;
            }
        }

        [return: NotNull]
        public override string GetText()
        {
            return string.Empty;
        }

        [return: NotNull]
        public override string GetText(RuleContext ctx)
        {
            return GetText(ctx.SourceInterval);
        }

        [return: NotNull]
        public override string GetText(IToken start, IToken stop)
        {
            if (start != null && stop != null)
            {
                return GetText(Interval.Of(start.TokenIndex, stop.TokenIndex));
            }
            throw new NotSupportedException("The specified start and stop symbols are not supported.");
        }

        public override void Consume()
        {
            if (LA(1) == TokenConstants.EOF)
            {
                throw new InvalidOperationException("cannot consume EOF");
            }
            // buf always has at least tokens[p==0] in this method due to ctor
            lastToken = _tokens[p];
            // track last token for LT(-1)
            //// if we're at last token and no markers, opportunity to flush buffer
            //if (p == n - 1 && numMarkers == 0)
            //{
            //    n = 0;
            //    p = -1;
            //    // p++ will leave this at 0
            //    lastTokenBufferStart = lastToken;
            //}
            p++;
            currentTokenIndex++;
            Sync(1);
        }

        protected new internal virtual bool Sync(int i)
        {
            return true;
        }

        protected internal virtual int Fill(int n)
        {
            return n;
        }

        public virtual void Add(IToken t)
        {
            if (t is IWritableToken)
            {
                ((IWritableToken)t).TokenIndex = GetBufferStartIndex() + n;
            }
            _tokens.Add(t);
            n++;
        }

        public override int Mark()
        {
            if (numMarkers == 0)
            {
                lastTokenBufferStart = lastToken;
            }
            int mark = -numMarkers - 1;
            numMarkers++;
            return mark;
        }

        public override void Release(int marker)
        {
            int expectedMark = -numMarkers;
            if (marker != expectedMark)
            {
                throw new InvalidOperationException("release() called with an invalid marker.");
            }
            numMarkers--;
            if (numMarkers == 0)
            {
                // can we release buffer?
                //if (p > 0)
                //{
                //    // Copy tokens[p]..tokens[n-1] to tokens[0]..tokens[(n-1)-p], reset ptrs
                //    // p is last valid token; move nothing if p==n as we have no valid char
                //    //                        System.Array.Copy(tokens, p, tokens, 0, n - p);
                //    // shift n-p tokens from p to 0
                //    n = n - p;
                //    p = 0;
                //}
                lastTokenBufferStart = lastToken;
            }
        }

        public override int Index
        {
            get
            {
                return currentTokenIndex;
            }
        }

        public override void Seek(int index)
        {
            // seek to absolute index
            if (index == currentTokenIndex)
            {
                return;
            }
            if (index > currentTokenIndex)
            {
                Sync(index - currentTokenIndex);
                index = Math.Min(index, GetBufferStartIndex() + n - 1);
            }
            int bufferStartIndex = GetBufferStartIndex();
            int i = index - bufferStartIndex;
            if (i < 0)
            {
                throw new ArgumentException("cannot seek to negative index " + index);
            }
            else
            {
                if (i >= n)
                {
                    throw new NotSupportedException("seek to index outside buffer: " + index + " not in " + bufferStartIndex + ".." + (bufferStartIndex + n));
                }
            }
            p = i;
            currentTokenIndex = index;
            if (p == 0)
            {
                lastToken = lastTokenBufferStart;
            }
            else
            {
                lastToken = _tokens[p - 1];
            }
        }

        public override int Size
        {
            get
            {
                return _tokens.Count;
            }
        }

        public override string SourceName
        {
            get
            {
                return TokenSource.SourceName;
            }
        }

        public string Text { get; set; }

        [return: NotNull]
        public override string GetText(Interval interval)
        {
            int bufferStartIndex = GetBufferStartIndex();
            int bufferStopIndex = bufferStartIndex + _tokens.Count - 1;
            int start = interval.a;
            int stop = interval.b;
            if (start < bufferStartIndex || stop > bufferStopIndex)
            {
                throw new NotSupportedException("interval " + interval + " not in token buffer window: " + bufferStartIndex + ".." + bufferStopIndex);
            }
            int a = start - bufferStartIndex;
            int b = stop - bufferStartIndex;
            StringBuilder buf = new StringBuilder();
            for (int i = a; i <= b; i++)
            {
                IToken t = _tokens[i];
                buf.Append(t.Text);
            }
            return buf.ToString();
        }

        protected internal int GetBufferStartIndex()
        {
            return currentTokenIndex - p;
        }

        public override IList<IToken> GetHiddenTokensToLeft(int tokenIndex, int channel)
        {
            if (tokenIndex < 0 || tokenIndex >= _tokens.Count)
            {
                throw new ArgumentOutOfRangeException(tokenIndex + " not in 0.." + (_tokens.Count - 1));
            }
            if (tokenIndex == 0)
            {
                // obviously no tokens can appear before the first token
                return null;
            }
            int prevOnChannel = PreviousTokenOnChannel(tokenIndex - 1, Lexer.DefaultTokenChannel);
            if (prevOnChannel == tokenIndex - 1)
            {
                return null;
            }
            // if none onchannel to left, prevOnChannel=-1 then from=0
            int from = prevOnChannel + 1;
            int to = tokenIndex - 1;
            return FilterForChannel(from, to, channel);
        }

        protected internal new int PreviousTokenOnChannel(int i, int channel)
        {
            //Sync(i);
            if (i >= Size)
            {
                // the EOF token is on every channel
                return Size - 1;
            }
            while (i >= 0)
            {
                IToken token = _tokens[i];
                if (token.Type == TokenConstants.EOF || token.Channel == channel)
                {
                    return i;
                }
                i--;
            }
            return i;
        }

        protected internal new IList<IToken> FilterForChannel(int from, int to, int channel)
        {
            IList<IToken> hidden = new List<IToken>();
            for (int i = from; i <= to; i++)
            {
                IToken t = _tokens[i];
                if (channel == -1)
                {
                    if (t.Channel != Lexer.DefaultTokenChannel)
                    {
                        hidden.Add(t);
                    }
                }
                else
                {
                    if (t.Channel == channel)
                    {
                        hidden.Add(t);
                    }
                }
            }
            if (hidden.Count == 0)
            {
                return null;
            }
            return hidden;
        }

        public void Delete()
        {
            _tokens.RemoveAt(currentTokenIndex);
            n--;
        }

        public void Move(int number, int from, int to)
        {
            // Move token at position "from" to position "to", in-place modified.
            if (from == -1 || to == -1) return;
            if (from < to)
            {
                // Slide "number" of tokens "from + 1" to "from".
                // Then move token at "from" to "number - 1".
                var ft = this._tokens[from];
                var tt = this._tokens[to]; // Side effect of making sure buffer full.
                int bufferStartIndex = GetBufferStartIndex();
                for (int j = 0; j < number; ++j, ++j)
                {
                    for (int i = from + 1; i < to; ++i)
                    {
                        _tokens[i - 1 - bufferStartIndex] = _tokens[i - bufferStartIndex];
                    }
                    _tokens[number - 1 - bufferStartIndex] = ft;
                }
            } else
            {
                int bufferStartIndex = GetBufferStartIndex();
                for (int j = 0; j < number; ++j)
                {
                    var ft = this._tokens[from];
                    var tt = this._tokens[to]; // Side effect of making sure buffer full.
                    for (int i = from; i >= to; --i)
                    {
                        _tokens[i - bufferStartIndex] = _tokens[i - 1 - bufferStartIndex];
                    }
                    _tokens[to - bufferStartIndex] = ft;
                    from++;
                    to++;
                }
            }
            for (int current = 0, i = 0; i < this.Size; ++i)
            {
                var t = this._tokens[i] as AltAntlr.MyToken;
                t.TokenIndex = i;
                t.StartIndex = current;
                t.StopIndex = current + t.Text.Length - 1;
                current = t.StopIndex + 1;
            }
        }

        public void Insert(int i, IToken payload)
        {
            this._tokens.Insert(i, payload);
            n++;
        }
    }
}
