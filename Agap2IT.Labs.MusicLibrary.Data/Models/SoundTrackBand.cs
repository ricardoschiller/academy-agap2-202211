using System;
using System.Collections.Generic;

namespace Agap2IT.Labs.MusicLibrary.Data.Models;

public partial class SoundTrackBand
{
    public int Id { get; set; }

    public int SoundTrackId { get; set; }

    public int BandId { get; set; }

    public bool IsLead { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public Guid Uuid { get; set; }

    public virtual Band Band { get; set; } = null!;

    public virtual SoundTrack SoundTrack { get; set; } = null!;
}
