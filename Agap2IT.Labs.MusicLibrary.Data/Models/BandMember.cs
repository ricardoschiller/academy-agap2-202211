using System;
using System.Collections.Generic;

namespace Agap2IT.Labs.MusicLibrary.Data.Models;

public partial class BandMember
{
    public int Id { get; set; }

    public int BandId { get; set; }

    public int ArtistId { get; set; }

    public DateTime JoinDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public Guid Uuid { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual Band Band { get; set; } = null!;
}
