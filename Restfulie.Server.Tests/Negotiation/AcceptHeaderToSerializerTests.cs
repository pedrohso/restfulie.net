﻿using NUnit.Framework;
using Restfulie.Server.Exceptions;
using Restfulie.Server.Marshalling.Serializers;
using Restfulie.Server.Negotitation;

namespace Restfulie.Server.Tests.Negotiation
{
    [TestFixture]
    public class AcceptHeaderToSerializerTests
    {
        [Test]
        public void ShouldReturnSerializerForAGivenMediaType()
        {
            var serializer = new AcceptHeaderToSerializer().For("application/xml");

            Assert.IsTrue(serializer is XmlAndHypermediaSerializer);
        }

        [Test]
        public void ShouldUnderstandMediaTypeExpression()
        {
            var serializer = new AcceptHeaderToSerializer().For("application/xml;q=0.2");

            Assert.IsTrue(serializer is XmlAndHypermediaSerializer);
        }

        [Test]
        public void ShouldReturnDefaultIfMediaTypeIsNotProvided()
        {
            var serializer = new AcceptHeaderToSerializer().For(null);

            Assert.IsTrue(serializer is XmlAndHypermediaSerializer);
        }

        [Test]
        [ExpectedException(typeof(MediaTypeNotSupportedException))]
        public void ShouldThrowAnExceptionIfMediaTypeIsInvalid()
        {
            new AcceptHeaderToSerializer().For("some-crazy-media-type");
        }
    }
}