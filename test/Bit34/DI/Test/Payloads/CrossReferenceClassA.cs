// Copyright (c) 2018 Oğuz Sandıkçı
// This code is licensed under MIT license (see LICENSE.txt for details)

using System;

namespace Bit34.DI.Test.Payloads
{
    public class CrossReferenceClassA
    {
        [Inject]
        public CrossReferenceClassB value;
    }
}
