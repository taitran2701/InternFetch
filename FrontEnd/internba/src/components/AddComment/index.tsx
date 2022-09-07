import React, { useEffect, useState } from "react";
import styles from "./index.module.scss";

export default function AddComment() {
  const [user, setUserName] = useState<{ userId: string }>();

  useEffect(() => {
    const user = localStorage.getItem("user");
    if (user) {
      setUserName(JSON.parse(user));
    }
  }, []);
  return (
    <React.Fragment>
      <img
        src="https://scontent.fsgn5-6.fna.fbcdn.net/v/t39.30808-6/300376547_5491598224258453_7351247412124304056_n.jpg?stp=dst-jpg_s851x315&_nc_cat=108&ccb=1-7&_nc_sid=dbeb18&_nc_ohc=n6ZxL-YpVwMAX-9WE82&_nc_ht=scontent.fsgn5-6.fna&oh=00_AT-SZy5SSMfyG54liZf8KiXdOgajE2k_A994fgC35z0K6A&oe=63125470"
        alt=""
      />

      <input
        type="text"
        placeholder="Write a public comment"
        className={styles.commentInput}
      />
      <p>{user?.userId}</p>
    </React.Fragment>
  );
}
