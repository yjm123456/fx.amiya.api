using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Domain.UserDomain.Events
{
  public  class MpUserUnsubscribeDomainEvent: DomainEvent
    {
        public MpUserUnsubscribeDomainEvent(IEntity source) : base(source)
        {
        }
    }
}
