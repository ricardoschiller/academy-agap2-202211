using System;
using System.Collections.Generic;

namespace Agap2IT.Labs.MusicLibrary.Data.Models;

public partial class Album
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string LogoImage { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public int DurationInSeconds { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public Guid Uuid { get; set; }

    public virtual ICollection<SoundTrack> SoundTracks { get; } = new List<SoundTrack>();
}
