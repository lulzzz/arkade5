﻿using Arkivverket.Arkade.Resources;
using Arkivverket.Arkade.Util;

namespace Arkivverket.Arkade.Tests.Noark5
{
    public class NumberOfClasses : CountElementsWithUniqueName
    {
        private readonly TestId _id = new TestId(TestId.TestKind.Noark5, 0); // TODO: Assign correct test number

        public NumberOfClasses() : base("klasse")
        {
        }

        public override TestId GetId()
        {
            return _id;
        }

        public override string GetName()
        {
            return Noark5Messages.NumberOfClasses;
        }

        protected override string GetResultMessage()
        {
            return Noark5Messages.NumberOfClassesMessage;
        }
    }
}