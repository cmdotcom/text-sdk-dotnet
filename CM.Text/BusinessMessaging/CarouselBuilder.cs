using System.Collections.Generic;
using CM.Text.BusinessMessaging.Model.MultiChannel;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging
{
    /// <summary>
    ///     Builder class to construct a CarouselMessage.
    /// </summary>
    [PublicAPI]
    public class CarouselBuilder
    {
        private readonly List<RichCard> _cards = new List<RichCard>();
        private readonly CarouselCardWidth _carouselCardWidth;

        /// <summary>
        ///     Initializes the builder
        /// </summary>
        /// <param name="carouselCardWidth"></param>
        public CarouselBuilder(CarouselCardWidth carouselCardWidth)
        {
            _carouselCardWidth = carouselCardWidth;
        }

        /// <summary>
        ///     Adds one card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public CarouselBuilder AddCard(RichCard card)
        {
            _cards.Add(card);
            return this;
        }

        /// <summary>
        ///     Construct the carousel
        /// </summary>
        /// <returns></returns>
        public CarouselMessage Build()
        {
            return new CarouselMessage
            {
                Carousel = new Carousel {Cards = _cards.ToArray(), CarouselCardWidth = _carouselCardWidth}
            };
        }
    }
}
