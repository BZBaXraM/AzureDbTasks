using Microsoft.EntityFrameworkCore;
using SynopsisOfTheNetworks.Mvc.Models;

namespace SynopsisOfTheNetworks.Mvc.Entities;

public class InfoContext : DbContext
{
    public InfoContext(DbContextOptions<InfoContext> options) : base(options)
    {
    }

    public virtual DbSet<InfoViewModel> Infos => Set<InfoViewModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var infos = new List<InfoViewModel>
        {
            new()
            {
                Id = Guid.NewGuid(),
                ProtocolName = "OSI",
                Info =
                    "Open Systems Interconnection (OSI) - это семиуровневая модель взаимодействия открытых систем, разработанная Международной организацией по стандартизации (ISO)." +
                    "    Модель OSI определяет семь уровней взаимодействия открытых систем. Каждый уровень выполняет определенные функции, которые взаимодействуют с функциями соседних уровней." +
                    "    Каждый уровень модели OSI выполняет определенные функции, которые взаимодействуют с функциями соседних уровней. Все уровни модели OSI разделены на две группы: нижние три уровня - физические, канальные и сетевые - обеспечивают передачу данных от одного узла к другому, а верхние три уровня - транспортный, сеансовый и представительный - обеспечивают передачу данных между приложениями." +
                    "    Седьмой уровень - прикладной - обеспечивает взаимодействие приложений с пользователем. Каждый уровень выполняет определенные функции, которые взаимодействуют с функциями соседних уровней." +
                    "    Все уровни модели OSI разделены на две группы: нижние три уровня - физические, канальные и сетевые - обеспечивают передачу данных от одного узла к другому, а верхние три уровня - транспортный, сеансовый и представительный - обеспечивают передачу данных между приложениями." +
                    "    Седьмой уровень - прикладной - обеспечивает взаимодействие приложений с пользователем.",
                Photo = "https://res.cloudinary.com/baxram97/image/upload/v1703177856/temp/gwgj0xr0vlygn7owkdri.webp",
            },
            new()
            {
                Id = Guid.NewGuid(),
                ProtocolName = "TCP/IP",
                Info =
                    "Протоколы TCP/IP - это семейство протоколов, которые используются для связи в сетях, включая Интернет. Протоколы TCP/IP используются для связи в сетях, включая Интернет." +
                    "    Протоколы TCP/IP используются для связи в сетях, включая Интернет. Протоколы TCP/IP используются для связи в сетях, включая Интернет. Протоколы TCP/IP используются для связи в сетях, включая Интернет. Протоколы TCP/IP используются для связи в сетях, включая Интернет. Протоколы TCP/IP используются для связи в сетях, включая Интернет.",
                Photo = "https://res.cloudinary.com/baxram97/image/upload/v1703177679/temp/xafljhnjp8poxaradqpp.png",
            },
            new()
            {
                Id = Guid.NewGuid(),
                ProtocolName = "UDP",
                Info =
                    "Протокол UDP - это протокол транспортного уровня, который используется для передачи данных в сетях, основанных на IP. Протокол UDP - это протокол транспортного уровня, который используется для передачи данных в сетях, основанных на IP. Протокол UDP - это протокол транспортного уровня, который используется для передачи данных в сетях, основанных на IP. Протокол UDP - это протокол транспортного уровня, который используется для передачи данных в сетях, основанных на IP. Протокол UDP - это протокол транспортного уровня, который используется для передачи данных в сетях, основанных на IP.",
                Photo = "https://res.cloudinary.com/baxram97/image/upload/v1703177679/temp/lqddsjxfmimjnpmd4rye.png",
            },
            new()
            {
                Id = Guid.NewGuid(),
                ProtocolName = "FTP",
                Port = "21",
                Info =
                    "Протокол передачи файлов (FTP) - это протокол прикладного уровня, который используется для передачи файлов между узлами в сетях, основанных на IP. Протокол передачи файлов (FTP) - это протокол прикладного уровня, который используется для передачи файлов между узлами в сетях, основанных на IP. Протокол передачи файлов (FTP) - это протокол прикладного уровня, который используется для передачи файлов между узлами в сетях, основанных на IP. Протокол передачи файлов (FTP) - это протокол прикладного уровня, который используется для передачи файлов между узлами в сетях, основанных на IP. Протокол передачи файлов (FTP) - это протокол прикладного уровня, который используется для передачи файлов между узлами в сетях, основанных на IP.",
                Photo = "https://res.cloudinary.com/baxram97/image/upload/v1703177679/temp/ga9c12uzjopaqrd7v3br.jpg",
            },
            new()
            {
                Id = Guid.NewGuid(),
                ProtocolName = "HTTP",
                Port = "80",
                Info =
                    "Протокол передачи гипертекста (HTTP) - это протокол прикладного уровня, который используется для передачи гипертекстовых документов в сетях, основанных на IP. Протокол передачи гипертекста (HTTP) - это протокол прикладного уровня, который используется для передачи гипертекстовых документов в сетях, основанных на IP. Протокол передачи гипертекста (HTTP) - это протокол прикладного уровня, который используется для передачи гипертекстовых документов в сетях, основанных на IP. Протокол передачи гипертекста (HTTP) - это протокол прикладного уровня, который используется для передачи гипертекстовых документов в сетях, основанных на IP. Протокол передачи гипертекста (HTTP) - это протокол прикладного уровня, который используется для передачи гипертекстовых документов в сетях, основанных на IP.",
                Photo = "https://res.cloudinary.com/baxram97/image/upload/v1703177679/temp/vwcotdehoabpiofj95tz.png",
            },
            new()
            {
                Id = Guid.NewGuid(),
                ProtocolName = "HTTPS",
                Port = "443",
                Info =
                    "Протокол безопасной передачи гипертекста (HTTPS) - это протокол прикладного уровня, который используется для передачи гипертекстовых документов в сетях, основанных на IP. Протокол безопасной передачи гипертекста (HTTPS) - это протокол прикладного уровня, который используется для передачи гипертекстовых документов в сетях, основанных на IP. Протокол безопасной передачи гипертекста (HTTPS) - это протокол прикладного уровня, который используется для передачи гипертекстовых документов в сетях, основанных на IP. Протокол безопасной передачи гипертекста (HTTPS) - это протокол прикладного уровня, который используется для передачи гипертекстовых документов в сетях, основанных на IP. Протокол безопасной передачи гипертекста (HTTPS) - это протокол прикладного уровня, который используется для передачи гипертекстовых документов в сетях, основанных на IP.",
                Photo = "https://res.cloudinary.com/baxram97/image/upload/v1703177808/temp/w7zxiombpeynhx2fudyf.jpg",
            },
            new()
            {
                Id = Guid.NewGuid(),
                ProtocolName = "SMTP",
                Port = "25",
                Info =
                    "Протокол простой почтовой передачи (SMTP) - это протокол прикладного уровня, который используется для отправки и получения электронной почты. Протокол простой почтовой передачи (SMTP) - это протокол прикладного уровня, который используется для отправки и получения электронной почты. Протокол простой почтовой передачи (SMTP) - это протокол прикладного уровня, который используется для отправки и получения электронной почты. Протокол простой почтовой передачи (SMTP) - это протокол прикладного уровня, который используется для отправки и получения электронной почты. Протокол простой почтовой передачи (SMTP) - это протокол прикладного уровня, который используется для отправки и получения электронной почты.",
                Photo = "https://res.cloudinary.com/baxram97/image/upload/v1703177679/temp/r4vcp9rgpu8dxphttvji.png",
            },
            new()
            {
                Id = Guid.NewGuid(),
                ProtocolName = "POP3",
                Port = "110",
                Info =
                    "Протокол почтового офиса 3 (POP3) - это протокол прикладного уровня, который используется для получения электронной почты. Протокол почтового офиса 3 (POP3) - это протокол прикладного уровня, который используется для получения электронной почты. Протокол почтового офиса 3 (POP3) - это протокол прикладного уровня, который используется для получения электронной почты. Протокол почтового офиса 3 (POP3) - это протокол прикладного уровня, который используется для получения электронной почты. Протокол почтового офиса 3 (POP3) - это протокол прикладного уровня, который используется для получения электронной почты.",
                Photo = "https://res.cloudinary.com/baxram97/image/upload/v1703177679/temp/ie6e937ld7n6spci5xgs.webp",
            },
            new()
            {
                Id = Guid.NewGuid(),
                ProtocolName = "IMAP",
                Port = "143",
                Info =
                    "Протокол доступа к сообщениям интернет-почты (IMAP) - это протокол прикладного уровня, который используется для получения электронной почты. Протокол доступа к сообщениям интернет-почты (IMAP) - это протокол прикладного уровня, который используется для получения электронной почты. Протокол доступа к сообщениям интернет-почты (IMAP) - это протокол прикладного уровня, который используется для получения электронной почты. Протокол доступа к сообщениям интернет-почты (IMAP) - это протокол прикладного уровня, который используется для получения электронной почты. Протокол доступа к сообщениям интернет-почты (IMAP) - это протокол прикладного уровня, который используется для получения электронной почты.",
                Photo = "https://res.cloudinary.com/baxram97/image/upload/v1703177680/temp/uh4crah1mil218ub6nic.jpg",
            },
            new()
            {
                Id = Guid.NewGuid(),
                ProtocolName = "RDP",
                Port = "3389",
                Info =
                    "Протокол удаленного рабочего стола (RDP) - это протокол прикладного уровня, который используется для удаленного управления компьютером. Протокол удаленного рабочего стола (RDP) - это протокол прикладного уровня, который используется для удаленного управления компьютером. Протокол удаленного рабочего стола (RDP) - это протокол прикладного уровня, который используется для удаленного управления компьютером. Протокол удаленного рабочего стола (RDP) - это протокол прикладного уровня, который используется для удаленного управления компьютером. Протокол удаленного рабочего стола (RDP) - это протокол прикладного уровня, который используется для удаленного управления компьютером.",
                Photo = "https://res.cloudinary.com/baxram97/image/upload/v1703177680/temp/hyziilvncwrrwjpe3ckl.png",
            }
        };

        modelBuilder.Entity<InfoViewModel>().HasData(infos);
    }
}