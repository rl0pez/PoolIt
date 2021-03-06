namespace PoolIt.Web.Areas.Rides.Models.Ride
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Invitation;
    using JoinRequest;
    using Profile.Models.Car;
    using Services.Models;

    public class RideDetailsViewModel : IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public CarListingViewModel Car { get; set; }

        public DateTime Date { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public int AvailableSeats { get; set; }

        public string PhoneNumber { get; set; }

        public string Notes { get; set; }

        public string ConversationId { get; set; }

        public string OrganiserEmail { get; set; }

        public string OrganiserFullName { get; set; }

        public string InvitationKey { get; set; }

        public ICollection<UserRideViewModel> Participants { get; set; }

        public ICollection<JoinRequestListingViewModel> JoinRequests { get; set; }

        public ICollection<InvitationViewModel> Invitations { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<RideServiceModel, RideDetailsViewModel>()
                .ForMember(dest => dest.OrganiserEmail, opt =>
                    opt.MapFrom(src => src.Car.Owner.Email))
                .ForMember(dest => dest.OrganiserFullName, opt =>
                    opt.MapFrom(src => $"{src.Car.Owner.FirstName} {src.Car.Owner.LastName}"));
        }
    }
}