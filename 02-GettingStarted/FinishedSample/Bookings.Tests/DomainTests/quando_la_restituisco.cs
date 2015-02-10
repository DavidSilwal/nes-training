﻿using System;
using Bookings.Domain.BookingContenxt;
using Machine.Specifications;

namespace Bookings.Tests.DomainTests
{
    [Subject("Risorsa")]
    public class quando_la_restituisco
    {
        static readonly Guid _id = new Guid("4534C386-5284-4203-9AA3-87B60A172764");
        static Risorsa item;

        Establish context = () =>
            {
                item = new Risorsa(_id, "MacBook Pro 13\"");
                item.Prendi();
            };

        Because of = () =>
            {
                item.Restituisci();
            };

        // transizioni di stato
        It questa_diventa_non_presa = () => item.Presa.ShouldBeFalse();

        // eventi
        It l_evento_di_restituita_e_stato_scatenato = () => item.RaisedEvent<RisorsaRestituita>().ShouldBeTrue();
    }
}