using System;
using System.Collections.Generic;

namespace Agap2IT.Labs.MusicLibrary.Data.Models;

public partial class SoundTrack
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DurationInSeconds { get; set; }

    public string? Image { get; set; }

    public string SoundBinary { get; set; } = null!;

    public int AlbumId { get; set; }

    public bool IsOriginal { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public Guid Uuid { get; set; }

    public virtual Album Album { get; set; } = null!;

    public virtual ICollection<SoundTrackBand> SoundTrackBands { get; } = new List<SoundTrackBand>();
}
