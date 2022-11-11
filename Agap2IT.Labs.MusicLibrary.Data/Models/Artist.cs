using System;
using System.Collections.Generic;

namespace Agap2IT.Labs.MusicLibrary.Data.Models;

public partial class Artist
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateBirth { get; set; }

    public int? BandId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public Guid Uuid { get; set; }

    public virtual ICollection<BandMember> BandMembers { get; } = new List<BandMember>();
}
