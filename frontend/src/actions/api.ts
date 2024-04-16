import axios from "axios";

const baseUrl = "https://yunomix280304-001-site1.ftempurl.com/api/";
const username = "11168186";
const password = "60-dayfreetrial";
const encodedCredentials = btoa(`${username}:${password}`);

interface HangHoa {
  id: number;
  ma_hanghoa: string;
  ten_hanghoa: string;
  so_luong: number;
  ghi_chu?: string;
}

export default {
  hangHoa(url = baseUrl + "HangHoa/") {
    return {
      fetchAll: (): Promise<HangHoa[]> =>
        axios.get(url, {
          headers: {
            Authorization: `Basic ${encodedCredentials}`,
          },
        }),
      fetchById: (id: number): Promise<HangHoa> =>
        axios.get(url + id, {
          headers: {
            Authorization: `Basic ${encodedCredentials}`,
          },
        }),
      create: (newRecord: HangHoa): Promise<HangHoa> =>
        axios.post(url, newRecord, {
          headers: {
            Authorization: `Basic ${encodedCredentials}`,
          },
        }),
      update: (id: number, updateRecord: HangHoa): Promise<void> =>
        axios.put(url + id, updateRecord, {
          headers: {
            Authorization: `Basic ${encodedCredentials}`,
          },
        }),
      delete: (id: number): Promise<void> =>
        axios.delete(url + id, {
          headers: {
            Authorization: `Basic ${encodedCredentials}`,
          },
        }),
    };
  },
};
