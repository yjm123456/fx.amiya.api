using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Domain.UserDomain.Events
{
    public class MpUserSubscribeDomainEvent: DomainEvent
    {
        public MpUserSubscribeDomainEvent(IEntity source) : base(source)
        {
        }
    }
}
