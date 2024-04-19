import axios from "axios";

const baseUrl = "https://yunomix280304-001-site1.ftempurl.com/api/";
const username = "11168186";
const password = "60-dayfreetrial";
const encodedCredentials = btoa(`${username}:${password}`);

export default {
  hangHoa(url = baseUrl + "HangHoa/") {
    return {
      fetchAll: () =>
        axios.get(url, {
          headers: {
            Authorization: `Basic ${encodedCredentials}`,
          },
        }),
      fetchById: (id) =>
        axios.get(url + id, {
          headers: {
            Authorization: `Basic ${encodedCredentials}`,
          },
        }),
      create: (newRecord) =>
        axios.post(url, newRecord, {
          headers: {
            Authorization: `Basic ${encodedCredentials}`,
          },
        }),
      update: (id, updateRecord) =>
        axios.put(url + id, updateRecord, {
          headers: {
            Authorization: `Basic ${encodedCredentials}`,
          },
        }),
      delete: (id) =>
        axios.delete(url + id, {
          headers: {
            Authorization: `Basic ${encodedCredentials}`,
          },
        }),
      deleteByCode: (id) =>
        axios.deleteByCode(url + id, {
          headers: {
            Authorization: `Basic ${encodedCredentials}`,
          },
        }),
    };
  },
};
