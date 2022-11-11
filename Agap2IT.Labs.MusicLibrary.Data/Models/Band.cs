using System;
using System.Collections.Generic;

namespace Agap2IT.Labs.MusicLibrary.Data.Models;

public partial class Band
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public Guid Uuid { get; set; }

    public string Image { get; set; } = null!;

    public virtual ICollection<BandMember> BandMembers { get; } = new List<BandMember>();

    public virtual ICollection<SoundTrackBand> SoundTrackBands { get; } = new List<SoundTrackBand>();
}
