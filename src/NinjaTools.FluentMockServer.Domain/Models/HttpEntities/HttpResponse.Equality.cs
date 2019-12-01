using System;

namespace NinjaTools.FluentMockServer.Domain.Models.HttpEntities
{
    /// <summary>
    ///     Model to describe how to respond to a matching <see cref="HttpRequest" />.
    /// </summary>
    public partial class HttpResponse : IIdentifiable<HttpResponse>
    {
        /// <inheritdoc />
        public int Id { get; }

        /// <inheritdoc />
        public DateTime CreatedOn { get; set; }

        /// <inheritdoc />
        public DateTime ModifiedOn{ get; set; }

        /// <inheritdoc />
        public byte[] Timestamp{ get; set; }
        
        /// <inheritdoc />
        public bool Equals(HttpResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return StatusCode == other.StatusCode && Equals(Delay, other.Delay) && Equals(ConnectionOptions, other.ConnectionOptions) && Equals(Body, other.Body) && Equals(Headers, other.Headers);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HttpResponse) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = StatusCode.GetHashCode();
                hashCode = (hashCode * 397) ^ (Delay != null ? Delay.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ConnectionOptions != null ? ConnectionOptions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Body != null ? Body.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Headers != null ? Headers.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
