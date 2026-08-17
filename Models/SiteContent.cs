using System.ComponentModel.DataAnnotations;

namespace GiveAID.Models
{
    /// <summary>
    /// Generic content model for editable website sections.
    /// SectionKey identifies the section:
    ///   AboutUs-WhatWeDo, AboutUs-OurMission, AboutUs-OurTeam,
    ///   HelpCentre-FAQ, ContactUs-Main, etc.
    /// </summary>
    public class SiteContent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string SectionKey { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
