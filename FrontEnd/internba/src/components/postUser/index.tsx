import { stringify } from "querystring";
import React, { useEffect, useState } from "react";
import styles from "./index.module.scss";

interface IUser {
  userName: string;
}

function PostUser() {
  const [user, setUserName] = useState<{ userName: string }>();

  useEffect(() => {
    const user = localStorage.getItem("user");
    if (user) {
      setUserName(JSON.parse(user));
      console.log(user);
    }
  }, []);

  return (
    <React.Fragment>
      <div className={styles.newsUser}>
        <div className={styles.userWrapper}>
          <div className={styles.userAvatar}>
            <img
              src="https://www.pngitem.com/pimgs/m/338-3388366_meme-for-steam-avatars-hd-png-download.png"
              alt=""
            />
          </div>
          <div>
            <div className={styles.userName}>{user?.userName}</div>
            <div className={styles.userTime}>12 hours ago</div>
          </div>
        </div>
        <div className={styles.userMore}>
          <img
            src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABmJLR0QA/wD/AP+gvaeTAAAAQUlEQVRIie3OMQqAMBBE0YenM3j/CyS5hxbaCsJahXmwzW9miYg1HZgYaIX+auB8rhc62L4s/q25v+rYCz0ilnEBbYAZX2fi+9QAAAAASUVORK5CYII="
            alt=""
          />
        </div>
      </div>
    </React.Fragment>
  );
}

export default PostUser;
