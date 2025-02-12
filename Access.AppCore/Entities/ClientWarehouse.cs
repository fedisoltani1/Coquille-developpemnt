﻿namespace Access.AppCore.Entities;

public class ClientWarehouse
{
    public ClientWarehouse()
    {
        Clients = new HashSet<Client>();
    }

    public int Id { get; set; }

    public int ClientId { get; set; }

    public string Intitule { get; set; } = null!;

    public int GouvernoratId { get; set; }

    public int VilleId { get; set; }

    public int CiteId { get; set; }

    public int ZoneId { get; set; }

    public virtual ICollection<Client> Clients { get; set; }
}
