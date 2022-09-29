import React, { useEffect, useState } from "react";
import { sortAndDeduplicateDiagnostics } from "typescript";
import styles from "./index.module.scss";

export interface IUpdatePost {
  show: boolean;
  onClose: () => void;
  id: string;
  upPost: any;
  attachment: string;
}
function UpdatePost(props: IUpdatePost) {
  const { onClose, id, upPost } = props;
  const [userId, setUserId] = useState<string>("");
  const [content, setContent] = useState<string>("");
  const [link, setLink] = useState<string>("");

  useEffect(() => {
    const user = localStorage.getItem("user");
    if (user) {
      setUserId(JSON.parse(user)?.userId);
    }
  });

  const updatePost = () => {
    fetch(`https://localhost:7076/api/Posts/${id}`, {
      method: "PUT",
      body: JSON.stringify({
        content: content,
        id: id,
        attachment: link,
      }),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((res) => {
        return res.json();
      })
      .then((post) => {
        setContent(post.content);
        upPost();
      })
      .catch((err) => {
        console.log(err.message);
      });
  };

  const handleUpdate = (e: any) => {
    e.preventDefault();
    updatePost();
    onClose();
  };

  if (!props.show) {
    return null;
  }
  return (
    <div className={styles.modal}>
      <div className={styles.content} onClick={(e) => e.stopPropagation()}>
        <div className={styles.header}>
          <h4 className={styles.title}>Update Post</h4>
        </div>
        <div className={styles.body}>
          <input
            type="text"
            value={content}
            onChange={(e) => setContent(e.target.value)}
          />
        </div>
        <div className={styles.header}>
          <h4 className={styles.title}>Add Attach</h4>
        </div>
        <div className={styles.body}>
          <input
            type="text"
            value={link}
            onChange={(e) => setLink(e.target.value)}
          />
        </div>
        <div className={styles.footer}>
          <div>
            <button onClick={handleUpdate}> Update</button>
            <button onClick={props.onClose} className={styles.button}>
              Cancel
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default UpdatePost;
