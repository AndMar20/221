﻿// The MIT License (MIT)
//
// Copyright (c) 2023 Henk-Jan Lebbink
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace AsmDude.Tools
{
    using System;

    [Flags]
    public enum AsmMessageEnum
    {
        NONE = 0,

        LABEL_UNDEFINED = 1 << 1,
        LABEL_CLASH = 1 << 2,
        INCLUDE_UNDEFINED = 1 << 3,
        SYNTAX_ERROR = 1 << 4,
        USAGE_OF_UNDEFINED = 1 << 5,
        NOT_IMPLEMENTED = 1 << 6,
        REDUNDANT = 1 << 7,
        UNREACHABLE = 1 << 8,

        DECORATE_REG = 1 << 9,
        OTHER = 1 << 10,
    }
}
