// Header.js
import React, { useEffect, useState } from "react";
import {
  View,
  Text,
  TouchableOpacity,
  Image,
  Modal,
  Dimensions,
} from "react-native";
import { COLORS } from "../../constants/Colors"; // Adjust the import path
import { SIZES, FONTS } from "../../constants/theme"; // Adjust the import path
import data from "../../data/data.json"; // Adjust the import path

const Header = () => {
  const [modalVisible, setModalVisible] = useState(false);
  const [SmallScreen, setSmallScreen] = useState(false);

  useEffect(() => {
    const updateLayout = () => {
      const { width } = Dimensions.get("window");
      setSmallScreen(width < 768);
    };

    const subscription = Dimensions.addEventListener("change", updateLayout);
    updateLayout();

    return () => {
      subscription?.remove();
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
    <View className="flex flex-row justify-between items-center p-4 bg-white rounded-b-lg shadow-md w-5/5">
      <View>
        <Text className="text-gray-600 text-lg">{greeting},</Text>
        <Text className="text-gray-800 text-xl font-bold">{data[0].userName}</Text>
      </View>

      <TouchableOpacity onPress={() => setModalVisible(true)}>
        <Image
          source={{ uri: data[0].profilePicture }}
          className={`w-12 h-12 rounded-full`}
        />
      </TouchableOpacity>

      <Modal
        transparent={true}
        animationType="slide"
        visible={modalVisible}
        onRequestClose={() => setModalVisible(false)}
      >
        <View className="flex-1 justify-center items-center bg-black bg-opacity-50">
          <View className="w-4/5 bg-white rounded-lg p-4 shadow-lg">
            <TouchableOpacity
              onPress={() => {
                setModalVisible(false);
              }}
              className="w-full p-4 items-center"
            >
              <Text className="text-lg text-gray-800">{`Profile`}</Text>
            </TouchableOpacity>
            <TouchableOpacity
              onPress={() => {
                setModalVisible(false);
              }}
              className="w-full p-4 items-center"
            >
              <Text className="text-lg text-gray-800">{`Logout`}</Text>
            </TouchableOpacity>
            <TouchableOpacity
              onPress={() => setModalVisible(false)}
              className="mt-4"
            >
              <Text className="text-blue-500">{`Close`}</Text>
            </TouchableOpacity>
          </View>
        </View>
      </Modal>
    </View>
  );
};

export default Header;
