
//@ts-nocheck
import React, { useEffect, useState } from "react";
import {
  View,
  Text,
  TouchableOpacity,
  StyleSheet,
  Image,
  Modal,
  Dimensions
} from "react-native";
import { Feather } from "@expo/vector-icons";
import { COLORS } from "../../constants/Colors";
import { SIZES, FONTS } from "../../constants/theme";
import data from "../../data/data.json";

export const Header = () => {
  const [modalVisible, setModalVisible] = useState(false);
  const [SmallScreen, setSmallScreen] = useState(false); // Moved inside the component

  useEffect(() => {
    const updateLayout = () => {
      const { width } = Dimensions.get("window");
      setSmallScreen(width < 768); // Update screen size state based on width
    };

    const subscription = Dimensions.addEventListener("change", updateLayout);
    updateLayout(); // Initial check when component mounts

    return () => {
      subscription?.remove(); // Clean up the subscription when component unmounts
    };
  }, []);

  const getGreeting = (): string => {
    const currentHour = new Date().getHours();
    if (currentHour < 12) {
      return "Good Morning";
    } else if (currentHour < 18) {
      return "Good Afternoon";
    } else {
      return "Good Evening";
    }
  };

  const greeting = getGreeting();

  return (
    <View style={styles.header}>
      <View>
        <Text style={styles.greeting}>{greeting},</Text>
        <Text style={styles.username}>{data[0].userName}</Text>
      </View>

      <TouchableOpacity onPress={() => setModalVisible(true)}>
        <Image
          source={{ uri: data[0].profilePicture }} // Correct profile picture
          style={[
            styles.avatar,
            {
              width: SmallScreen ? SIZES.width * 0.03 : SIZES.width * 0.03, 
              height: SmallScreen ? SIZES.width * 0.03 : SIZES.width * 0.03,
              borderRadius: SmallScreen ? (SIZES.width * 0.1) / 2 : (SIZES.width * 0.03) / 2,
            },
          ]}
        />
      </TouchableOpacity>

      {/* Modal for Profile Options */}
      <Modal
        transparent={true}
        animationType="slide"
        visible={modalVisible}
        onRequestClose={() => setModalVisible(false)}
      >
        <View style={styles.modalOverlay}>
          <View style={styles.modalContainer}>
            <TouchableOpacity
              onPress={() => {
                // Profile navigation logic here
                setModalVisible(false); // Close modal on profile press
              }}
              style={styles.modalOption}
            >
              <Text style={styles.modalText}>Profile</Text>
            </TouchableOpacity>
            <TouchableOpacity
              onPress={() => {
                // Handle logout logic here
                setModalVisible(false);
              }}
              style={styles.modalOption}
            >
              <Text style={styles.modalText}>Logout</Text>
            </TouchableOpacity>
            <TouchableOpacity
              onPress={() => setModalVisible(false)}
              style={styles.closeButton}
            >
              <Text style={styles.closeButtonText}>Close</Text>
            </TouchableOpacity>
          </View>
        </View>
      </Modal>
    </View>
  );
};

const styles = StyleSheet.create({
  header: {
    flexDirection: "row",
    justifyContent: "space-between",
    alignItems: "center",
    padding: SIZES.padding,
    backgroundColor: COLORS.white,
    borderBottomLeftRadius: SIZES.radius,
    borderBottomRightRadius: SIZES.radius,
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,
    elevation: 5,
  },
  greeting: {
    ...FONTS.h3,
    color: COLORS.textLight,
  },
  username: {
    ...FONTS.h2,
    color: COLORS.text,
  },
  avatar: {
    // Avatar styles (width, height, borderRadius are dynamically set)
  },
  modalOverlay: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    backgroundColor: "rgba(0, 0, 0, 0.5)",
  },
  modalContainer: {
    width: "80%",
    backgroundColor: COLORS.white,
    borderRadius: SIZES.radius,
    padding: SIZES.padding,
    alignItems: "center",
    elevation: 5,
  },
  modalOption: {
    width: "80%",
    padding: SIZES.padding,
    alignItems: "center",
  },
  modalText: {
    ...FONTS.h2,
    color: COLORS.text,
  },
  closeButton: {
    marginTop: SIZES.padding,
  },
  closeButtonText: {
    ...FONTS.body3,
    color: COLORS.primary,
  },
});
