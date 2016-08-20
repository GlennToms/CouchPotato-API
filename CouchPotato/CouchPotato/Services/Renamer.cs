using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CouchPotato.Model;

namespace CouchPotato.Services
{
    public class RenamerService
    {
        private readonly HttpClient _client;

        public RenamerService()
        {
            _client = new HttpClient();
        }

        public bool IsScanning()
        {
            const string command = "/renamer.progress";

            var result = _client.GetJson<StatusCodes>(command);

            return result.IsSuccess;
        }

        /// <summary>
        /// For the renamer to check for new files to rename in a folder.
        /// </summary>
        /// <param name="files">Provide the release files if more releases are in the same media_folder, delimited with a '|'. Note that no dedicated release folder is expected for releases with one file.</param>
        /// <param name="folderBase">The folder to find releases in. Leave empty for default folder.</param>
        /// <param name="downloadId">The nzb/torrent ID of the release in media_folder. 'downloader' is required with this option.</param>
        /// <param name="status">The status of the release: 'completed' (default) or 'seeding'</param>
        /// <param name="toFolder">The folder to move releases to. Leave empty for default folder.</param>
        /// <param name="mediaFolder">The folder of the media to scan. Keep empty for default renamer folder.</param>
        /// <param name="downloader">The downloader the release has been downloaded with. 'download_id' is required with this option.</param>
        /// <returns></returns>
        public StatusCodes Rename(
            string files = null, 
            string folderBase = null, 
            string downloadId = null, 
            string status = null, 
            string toFolder = null, 
            string mediaFolder = null, 
            string downloader = null
            )
        {
            const string command = "/renamer.scan";

            var newCommand = new StringBuilder(command);

            if (!string.IsNullOrWhiteSpace(files))
            {
                newCommand.Append("/?files=" + files);
            }

            if (!string.IsNullOrWhiteSpace(folderBase))
            {
                newCommand.Append("/?folder_base=" + folderBase);
            }

            if (!string.IsNullOrWhiteSpace(downloadId))
            {
                newCommand.Append("/?download_id=" + downloadId);
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                newCommand.Append("/?status=" + status);
            }

            if (!string.IsNullOrWhiteSpace(toFolder))
            {
                newCommand.Append("/?to_folder=" + toFolder);
            }

            if (!string.IsNullOrWhiteSpace(mediaFolder))
            {
                newCommand.Append("/?media_folder=" + mediaFolder);
            }

            if (!string.IsNullOrWhiteSpace(downloader))
            {
                newCommand.Append("/?downloader=" + downloader);
            }

            var result = _client.GetJson<StatusCodes>(newCommand.ToString());

            return result;
        }
    }
}
