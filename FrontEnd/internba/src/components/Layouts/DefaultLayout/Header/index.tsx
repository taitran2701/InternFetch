import * as React from "react";
import { useState, useEffect } from "react";

export interface IHeaderProps {}
interface IUser {
  username: string;
  password: string;
  email: string;
  avater: string;
  comments: string | null;
  posts: string | null;
  room: string | null;
  userRooms: string | null;
  id: string;
  deleteAt: string | null;
  createdDate: string;
  updatedDate: string;
}
export default function Header(props: IHeaderProps) {
  const [users, setUsers] = useState<IUser[]>([]);
  const [baseUser, setBaseUser] = useState<IUser[]>([]);
  useEffect(() => {
    fetch("https://localhost:7076/api/Users")
      .then((res) => res.json())
      .then((users) => {
        setUsers(users);
        setBaseUser(users);
      });
  }, []);
  const handleSearchChange = (e: any) => {
    let currentUsers = [...baseUser];
    currentUsers = baseUser.filter((user: IUser) =>
      user.username.includes(e.target.value)
    );
    setUsers(currentUsers);
  };
  return (
    <div>
      <div>
        <h1>Intern Fetch</h1>
        <input onChange={handleSearchChange} />
        <ul>
          {users.map((user: IUser) => {
            return <li key={user.id}>{user.username}</li>;
          })}
        </ul>
        <button>Upload</button>
        <button>Message</button>
      </div>
    </div>
  );
}
