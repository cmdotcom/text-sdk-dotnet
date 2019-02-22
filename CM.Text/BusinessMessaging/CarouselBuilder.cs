using System.Collections.Generic;
using CM.Text.BusinessMessaging.Model.MultiChannel;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging {
    /// <summary>
    /// Builder class to construct a CarouselMessage.
    /// </summary>
    [PublicAPI]
    public class CarouselBuilder {
        private readonly CarouselCardWidth carouselCardWidth;
        private List<RichCard> cards;

        /// <summary>
        /// Initializes the builder
        /// </summary>
        /// <param name="carouselCardWidth"></param>
        public CarouselBuilder(CarouselCardWidth carouselCardWidth) {
            this.carouselCardWidth = carouselCardWidth;
            cards = new List<RichCard>();
        }

        /// <summary>
        /// Adds one card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public CarouselBuilder AddCard(RichCard card) {
            cards.Add(card);
            return this;
        }

        /// <summary>
        /// Construct the carousel
        /// </summary>
        /// <returns></returns>
        public CarouselMessage Build() {
            return new CarouselMessage {
                Carousel = new Carousel {
                    Cards = cards.ToArray(),
                    CarouselCardWidth = carouselCardWidth
                }
            };
        }
    }
}
